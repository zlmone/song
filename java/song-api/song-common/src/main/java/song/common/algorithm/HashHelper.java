package song.common.algorithm;import java.security.MessageDigest;import java.security.NoSuchAlgorithmException;/** * description: * author:          song * createDate:      2018/6/11 */public class HashHelper {    /**     * md5平衡算法     * @param value     * @return     * @throws NoSuchAlgorithmException     */    public static long md5(String value) throws NoSuchAlgorithmException {        MessageDigest md5 = MessageDigest.getInstance("MD5");        md5.reset();        md5.update(value.getBytes());        byte[] bKey = md5.digest();        //具体的哈希函数实现细节--每个字节 & 0xFF 再移位        long result = ((long) (bKey[3] & 0xFF) << 24)                | ((long) (bKey[2] & 0xFF) << 16                | ((long)(bKey[1] & 0xFF) << 8) | (bKey[0] & 0xFF));        return result & 0xffffffffL;    }    /**     * FNV1_32_HASH算法     * @param value     * @return     */    public static long fnv1(String value) {        final int p = 16777619;        long hash =  2166136261L;        for (int i = 0; i < value.length(); i++) {            hash = (hash ^ value.charAt(i)) * p;        }        hash += hash << 13;        hash ^= hash >> 7;        hash += hash << 3;        hash ^= hash >> 17;        hash += hash << 5;        // 如果算出来的值为负数则取其绝对值        if (hash < 0) {            hash = Math.abs(hash);        }        return hash;    }}